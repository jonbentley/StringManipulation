
namespace StringManipulation.Components
{
    using System;
    using System.Xml;

    using StringManipulation.Extensions;

    public class XmlUtilitiesComponent
    {
        public Tuple<bool, string, string> SortXmlNodes(string xml)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }
            catch (Exception e)
            {
                return Tuple.Create(false, e.Message, string.Empty);
            }

            SortXml(doc.DocumentElement);

            // format the xml
            string sortedXml = doc.OuterXml.FormatXmlString();

            return Tuple.Create(true, String.Empty, sortedXml);
        }

        /// -----------------------------------------------------------
        /// <summary>
        /// In place pre-order recursive alphabetical sorting of the XmlNodes child 
        /// elements and <see cref="System.Xml.XmlAttributeCollection" />.
        /// </summary>
        /// <param name="rootNode">The root to be sorted.</param>
        /// -----------------------------------------------------------
        public static void SortXml(XmlNode rootNode)
        {
            SortAttributes(rootNode.Attributes);
            SortElements(rootNode);
            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                SortXml(childNode);
            }
        }

        /// -----------------------------------------------------------
        /// <summary>
        /// Sorts an attributes collection alphabetically.
        /// It uses the bubble sort algorithm.
        /// </summary>
        /// <param name="attribCol">The attribute collection to be sorted.</param>
        /// -----------------------------------------------------------
        public static void SortAttributes(XmlAttributeCollection attribCol)
        {
            if (attribCol == null)
                return;

            bool hasChanged = true;
            while (hasChanged)
            {
                hasChanged = false;
                for (int i = 1; i < attribCol.Count; i++)
                {
                    if (String.Compare(attribCol[i].Name, attribCol[i - 1].Name, true) < 0)
                    {
                        //Replace
                        attribCol.InsertBefore(attribCol[i], attribCol[i - 1]);
                        hasChanged = true;
                    }
                }
            }

        }

        /// -----------------------------------------------------------
        /// <summary>
        /// Sorts a <see cref="XmlNodeList" /> alphabetically, by the names of the elements.
        /// It uses the bubble sort algorithm.
        /// </summary>
        /// <param name="node">The node in which its childNodes are to be sorted.</param>
        /// -----------------------------------------------------------
        public static void SortElements(XmlNode node)
        {
            bool changed = true;
            while (changed)
            {
                changed = false;
                for (int i = 1; i < node.ChildNodes.Count; i++)
                {
                    if (String.Compare(node.ChildNodes[i].Name, node.ChildNodes[i - 1].Name, true) < 0)
                    {
                        //Replace:
                        node.InsertBefore(node.ChildNodes[i], node.ChildNodes[i - 1]);
                        changed = true;
                    }
                }
            }
        }
    }
}
