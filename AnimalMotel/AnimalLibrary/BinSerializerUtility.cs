using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnimalMotel
{
    class BinSerializerUtility
    {
        /// <summary>
        /// Function serializing any type of object 
        /// </summary>
        /// <param name="objToSave"> Object to be serialized. This object 
        /// must be Serializable.</param>
        /// <param name="fileName">File path including the name of the file to be serialized.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool Serialize(object objToSave, string fileName)
        {
            FileStream fileObj = null;
            try
            {
                //Steps in serializing an object
                fileObj = new FileStream(fileName, FileMode.Create);
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fileObj, objToSave);
            }
            catch (Exception ex) //no parameter - catch avoids exception throwing but no action is taken here 
            {
                Console.WriteLine("Error: " + ex);
                return false;
            }
            finally
            {
                if (fileObj != null)
                    fileObj.Close();

            }
            return true;
        }

        /// <summary>
        /// Generic method for deserializing any type of object 
        /// </summary>
        /// <typeparam name="T"> Any object</typeparam>
        /// <param name="filepath">File path including the name of the file to be deserialized</param>
        /// <returns></returns>
        /// <remarks>Object must not have changed its structure since it was serilized calling
        /// the above method.</remarks>
        public static T Deserialize<T>(string filepath)
        {
            FileStream objFromFile = null;
            object restoreObj = null;

            try
            {
                if (!File.Exists(filepath))
                {
                    throw new FileNotFoundException("The file is not found. ", filepath);
                }

                objFromFile = new FileStream(filepath, FileMode.Open);
                objFromFile.Seek(0, SeekOrigin.Begin);
                BinaryFormatter binFormatter = new BinaryFormatter();
                restoreObj = binFormatter.Deserialize(objFromFile);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.FileName + " -" + ex.Message);
            }
            finally
            {
                if (objFromFile != null)
                {
                    objFromFile.Close();
                }
            }

            return (T)restoreObj;
        }
    }
}
