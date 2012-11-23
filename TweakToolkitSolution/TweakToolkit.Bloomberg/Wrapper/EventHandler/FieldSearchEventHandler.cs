using System;
using Bloomberglp.Blpapi;

namespace TweakToolkit.Bloomberg.Wrapper.EventHandler
{
    internal class FieldSearchEventHandler : AEventHandlerBase
    {
        protected const int ID_LEN = 13;
        protected const int MNEMONIC_LEN = 36;
        protected const int DESC_LEN = 40;
        protected const string PADDING = "                                            ";

        public override void ProcessEvent(Event eventObj, BloombergSessionWrapper session)
        {
            foreach (Message msg in eventObj)
            {
                Element fields = msg.GetElement(FieldDataElementId);
                int numElements = fields.NumValues;

                PrintHeader();
                for (int i = 0; i < numElements; i++)
                {
                    PrintField(fields.GetValueAsElement(i));
                }
                Console.WriteLine();
            }
        }

        private void PrintField(Element field)
        {
            String fldDesc;

            string fldId = field.GetElementAsString(IdElementId);
            if (field.HasElement(FieldInfoElementId))
            {
                Element fldInfo = field.GetElement(FieldInfoElementId);
                string fldMnemonic = fldInfo.GetElementAsString(FieldMnemonicElementId);
                fldDesc = fldInfo.GetElementAsString(FieldDescElementId);

                Console.WriteLine(PadString(fldId, ID_LEN) +
                                  PadString(fldMnemonic, MNEMONIC_LEN) +
                                  PadString(fldDesc, DESC_LEN));
            }
            else
            {
                Element fldError = field.GetElement(FieldErrorElementId);
                fldDesc = fldError.GetElementAsString(FieldMsgElementId);

                Console.WriteLine("\n ERROR: " + fldId + " - " + fldDesc);
            }
        }

        private static void PrintHeader()
        {
            Console.WriteLine(PadString("FIELD ID", ID_LEN) +
                              PadString("MNEMONIC", MNEMONIC_LEN) +
                              PadString("DESCRIPTION", DESC_LEN));
            Console.WriteLine(PadString("-----------", ID_LEN) +
                              PadString("-----------", MNEMONIC_LEN) +
                              PadString("-----------", DESC_LEN));
        }

        private static String PadString(String str, int width)
        {
            if (str.Length >= width || str.Length >= PADDING.Length) return str;
            else return str + PADDING.Substring(0, width - str.Length);
        }
    }
}