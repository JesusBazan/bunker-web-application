using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.CompilerServices;

namespace WebAppProducto3
{
    public static class encrypt
    {
        public static byte[] firma;
        public static byte[] mensaje;
        // Crear una instancia de la clase de implementación DSA
        static DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
        public static byte[] firmar(byte[] mensaje)
        {
            // Creando el código hash para el mensaje, usando SHA-1
            byte[] codigoHash = HashAlgorithm.Create("SHA1").ComputeHash(mensaje);

            // Creamos el formateador de firmas
            DSASignatureFormatter formateador = new DSASignatureFormatter();

            // Establecemos la instancia del algoritmo DSA que firmará los datos.
            formateador.SetKey(dsa);

            // Establecemos el nombre del algoritmo hash que será usado para crear el código hash.
            formateador.SetHashAlgorithm("SHA1");

            // Creamos la firma DSA formateada
            byte[] firma = formateador.CreateSignature(codigoHash);

            return firma;
        }

        public static bool verificarFirma(byte[] mensaje, byte[] firma)
        {
            //Verificar
            // Creando el código hash para el mensaje, usando SHA-1
            byte[] codigoHash = HashAlgorithm.Create("SHA1").ComputeHash(mensaje);

            // Creamos el desformateador de firmas
            DSASignatureDeformatter desFormateador = new DSASignatureDeformatter();

            // Establecemos la instancia del algoritmo DSA que verificará la firma.
            desFormateador.SetKey(dsa);

            // Establecemos el mismo algoritmo hash que se usó para crear el código hash.
            desFormateador.SetHashAlgorithm("SHA1");

            // Verificamos la firma DSA.
            bool firmaValida = desFormateador.VerifySignature(codigoHash, firma);

            return firmaValida;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////// I G N O R A R ////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        //guardar tipo de usuario conectado
        public static int tipo = 0;
        public static void guardarRol(int rol)
        {
            tipo = rol;
        }

        //Transformar a byte[]
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        //Contraseña
        /// Encripta una cadena
        public static string Encriptar(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        //HASH
        public enum Supported_HA
        {
            //Variables enum que facilitan el uso de un método determinado
            SHA1, SHA256, SHA384, SHA512, MD5
        }

        public static string ComputeHash(string plainText, Supported_HA hash, byte[] salt)
        {
            //salt minimo y maximo
            int minSaltLength = 4, maxSaltLength = 16;

            byte[] saltBytes = null;
            if (salt != null)
            {
                saltBytes = salt;
            }
            else
            {
                //Creacion del Salt
                Random r = new Random();
                int SaltLength = r.Next(minSaltLength, maxSaltLength);
                saltBytes = new byte[SaltLength];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(saltBytes);
                rng.Dispose();
            }

            //Codificacion del texto con ASCII
            byte[] plainData = ASCIIEncoding.UTF8.GetBytes(plainText);
            byte[] plainDataWithSalt = new byte[plainData.Length + saltBytes.Length];

            //Aplicacion del Salt
            for (int x = 0; x < plainData.Length; x++)
                plainDataWithSalt[x] = plainData[x];
            for (int n = 0; n < saltBytes.Length; n++)
                plainDataWithSalt[plainData.Length + n] = saltBytes[n];

            byte[] hashValue = null;
            //Uso de un Hash determinado
            switch (hash)
            {
                case Supported_HA.SHA256:
                    SHA256Managed sha = new SHA256Managed();
                    hashValue = sha.ComputeHash(plainDataWithSalt);
                    sha.Dispose();
                    break;
                case Supported_HA.SHA1:
                    SHA1Managed sha1 = new SHA1Managed();
                    hashValue = sha1.ComputeHash(plainDataWithSalt);
                    sha1.Dispose();
                    break;
                case Supported_HA.SHA512:
                    SHA512Managed sha2 = new SHA512Managed();
                    hashValue = sha2.ComputeHash(plainDataWithSalt);
                    sha2.Dispose();
                    break;
                case Supported_HA.MD5:
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    hashValue = md5.ComputeHash(plainDataWithSalt);
                    md5.Dispose();
                    break;
            }
            //Salt + Hash
            byte[] result = new byte[hashValue.Length + saltBytes.Length];
            for (int x = 0; x < hashValue.Length; x++)
                result[x] = hashValue[x];
            for (int n = 0; n < saltBytes.Length; n++)
                result[hashValue.Length + n] = saltBytes[n];

            return Convert.ToBase64String(result);
        }

        public static bool Confirm(string plainText, string hashValue, Supported_HA hash)
        {
            //Obtener el arreglo del texto encriptado
            byte[] hashBytes = Convert.FromBase64String(hashValue);
            int hashSize = 0;

            switch (hash)
            {
                //Identificacion del tipo de Hash al que pertenece
                case Supported_HA.SHA256:
                    hashSize = 32;
                    break;
                case Supported_HA.SHA1:
                    hashSize = 20;
                    break;
                case Supported_HA.SHA512:
                    hashSize = 64;
                    break;
                case Supported_HA.MD5:
                    hashSize = 16;
                    break;
            }
            //Salt
            byte[] saltBytes = new byte[hashBytes.Length - hashSize];

            for (int x = 0; x < saltBytes.Length; x++)
                saltBytes[x] = hashBytes[hashSize + x];
            //Verificacion del cifrado de textos
            string newHash = ComputeHash(plainText, hash, saltBytes);

            return (hashValue == newHash);
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        //Simétrico

        // se define el tamaño del key y del vector
        private static readonly int tamanyoClave = 32;
        private static readonly int tamanyoVector = 16;

        // Define la palabra clave para el cifrado y
        private static string Clave = "";
        private static string Vector = "";
        public static void Key_IV(string key, string iv)
        {
            Clave = key;
            Vector = iv;
        }

        // se convierte el vector y la key a bytes
        public static byte[] Key = UTF8Encoding.UTF8.GetBytes(Clave);
        public static byte[] IV = UTF8Encoding.UTF8.GetBytes(Vector);

        //AES
        public static string CifradoTextoAES(String txtPlano)
        {
            Array.Resize(ref Key, tamanyoClave);
            Array.Resize(ref IV, tamanyoVector);

            // se establece cifrado
            MemoryStream memoryStream = new MemoryStream();

            // se instancia el Rijndael (AES)
            Rijndael RijndaelAlg = Rijndael.Create();

            // se crea el flujo de datos de cifrado
            //AES
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                RijndaelAlg.CreateEncryptor(Key, IV),
                CryptoStreamMode.Write);

            // se obtine la información a cifrar
            byte[] txtPlanoBytes = UTF8Encoding.UTF8.GetBytes(txtPlano);

            // se cifran los datos
            cryptoStream.Write(txtPlanoBytes, 0, txtPlanoBytes.Length);
            cryptoStream.FlushFinalBlock();

            // se obtinen los datos cifrados
            byte[] cipherMessageBytes = memoryStream.ToArray();

            // se cierra todo
            memoryStream.Close();
            cryptoStream.Close();

            // Se devuelve la cadena cifrada
            return Convert.ToBase64String(cipherMessageBytes);
        }

        public static string DescifradoTextoAES(String txtCifrado)
        {
            Array.Resize(ref Key, tamanyoClave);
            Array.Resize(ref IV, tamanyoVector);

            // se obtienen los bytes para el cifrado
            byte[] cipherTextBytes = Convert.FromBase64String(txtCifrado);

            // se almacenan los datos descifrados
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

			// se crea una instancia del Rijndael			
			Rijndael RijndaelAlg = Rijndael.Create();

            // se crean los datos cifrados
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // se descifran los datos
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                RijndaelAlg.CreateDecryptor(Key, IV),
                CryptoStreamMode.Read);

            // se obtienen datos descifrados
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            // se cierra todo
            memoryStream.Close();
            cryptoStream.Close();

            // se devuelve los datos descifrados
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

        //DES
        public static DESCryptoServiceProvider met;
        public static void guardarMetDES(DESCryptoServiceProvider metodo)
        {
            met = metodo;
        }
        public static string CifradoTextoDES(String txtPlano)
        {
            // se establece cifrado
            MemoryStream memoryStream = new MemoryStream();

            //instancia de método DES
            DESCryptoServiceProvider desmethod = new DESCryptoServiceProvider();

            //creacion de llave y de vector
            desmethod.GenerateKey();
            desmethod.GenerateIV();

            //guardado de del metodo DES para uso en desencriptado
            guardarMetDES(desmethod);

            // se crea el flujo de datos de cifrado
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                desmethod.CreateEncryptor(desmethod.Key, desmethod.IV),
                CryptoStreamMode.Write);

            // se obtine la información a cifrar
            byte[] txtPlanoBytes = UTF8Encoding.UTF8.GetBytes(txtPlano);

            // se cifran los datos
            cryptoStream.Write(txtPlanoBytes, 0, txtPlanoBytes.Length);
            cryptoStream.FlushFinalBlock();

            // se obtinen los datos cifrados
            byte[] cipherMessageBytes = memoryStream.ToArray();

            // se cierra todo
            memoryStream.Close();
            cryptoStream.Close();

            // Se devuelve la cadena cifrada
            return Convert.ToBase64String(cipherMessageBytes);
        }

        public static string DescifradoTextoDES(String txtCifrado)
        {
            // se obtienen los bytes para el cifrado
            byte[] cipherTextBytes = Convert.FromBase64String(txtCifrado);

            // se almacenan los datos descifrados
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            //instancia de método DES
            DESCryptoServiceProvider desmethod = met;
            ICryptoTransform ict = desmethod.CreateDecryptor(desmethod.Key, desmethod.IV);

            // se crean los datos cifrados

            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // se descifran los datos
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                desmethod.CreateEncryptor(desmethod.Key, desmethod.IV),
                CryptoStreamMode.Write);

            // se obtienen datos descifrados
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            // se cierra todo
            memoryStream.Close();
            cryptoStream.Close();

            // se devuelve los datos descifrados
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        //Asimétrico
        /////////////////////////////////////////
        //RSA
        public static string dirPruebas = @"D:\P02";
        public static string ficPruebas = Path.Combine(dirPruebas, "MisClaves_CS.xml");
        public static void crearXMLclaves(string ficPruebas)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string xmlKey = rsa.ToXmlString(true);

            // Si no existe el directorio, crearlo
            string dirPruebas = Path.GetDirectoryName(ficPruebas);

            if (Directory.Exists(dirPruebas) == false)
            {
                Directory.CreateDirectory(dirPruebas);
            }

            using (StreamWriter sw = new StreamWriter(ficPruebas, false, Encoding.UTF8))
            {
                sw.WriteLine(xmlKey);
                sw.Close();
            }

        }

        public static string clavesXML(string fichero)
        {
            string s;

            using (StreamReader sr = new StreamReader(fichero, Encoding.UTF8))
            {
                s = sr.ReadToEnd();
                sr.Close();
            }

            return s;
        }

        public static byte[] CifrarRSA(string texto, string xmlKeys)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            rsa.FromXmlString(xmlKeys);

            byte[] datosEnc = rsa.Encrypt(Encoding.Default.GetBytes(texto), false);

            return datosEnc;
        }

        public static string DescifrarRSA(byte[] datosEnc, string xmlKeys)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            rsa.FromXmlString(xmlKeys);

            byte[] datos = rsa.Decrypt(datosEnc, false);

            string res = Encoding.Default.GetString(datos);

            return res;
        }
    }
}