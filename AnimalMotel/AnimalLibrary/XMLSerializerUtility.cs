using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace AnimalMotel
{
    class XMLSerializerUtility
    {
        /// <summary>
        /// A generic method that can be used to serialize any type of object.
        /// The type of object is defined at method call by the client object
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="filePath">File to which data is to be srialized</param>
        /// <param name="objectToSave">Object containing data to be serialized. This object 
        /// must be Serializable.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool Serialize<T>(T objectToSave, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(filePath);
            try
            {
                serializer.Serialize(writer, objectToSave);
            }
            finally
            {
                if (writer != null)

                    writer.Close();
            }
            return true;
        }

        /// <summary>
        /// Deserialize any xml file serialized  using the above method.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <param name="fileName">XML file to be deserialized.</param>
        /// <returns>The object containing data read from the xml file.</returns>
        /// <remarks>Object must not have changed its structure since it was serilized calling
        /// the above method.</remarks>
        public static T Deserialize<T>(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            object restoredObj = null;
            //to be returned with data

            TextReader reader = null;

            try
            {
                reader = new StreamReader(fileName);
                restoredObj = (T)serializer.Deserialize(reader);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.FileName + " -" + ex.Message);
                return (T)restoredObj;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return (T)restoredObj;
        }
    }
}
