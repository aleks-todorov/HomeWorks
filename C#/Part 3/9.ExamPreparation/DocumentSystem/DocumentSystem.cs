using System;
using System.Collections.Generic;
using System.Text;
using DocumentSystem_1;
using System.Linq;

public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}

public class DocumentSystem
{
    private static IList<IDocument> documents = new List<IDocument>();
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == string.Empty)
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddDocument(IDocument doc, string[] attributes)
    {
        foreach (var attribut in attributes)
        {
            string[] tokens = attribut.Split('=');
            string propName = tokens[0];
            string propValue = tokens[1];
            doc.LoadProperty(propName, propValue);
        }
        if (doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: {0}", doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddTextDocument(string[] attributes)
    {

        AddDocument(new TextDocument(), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {

        AddDocument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(), attributes);
    }

    private static void ListDocuments()
    {
        if (documents.Count != 0)
        {
            foreach (var doc in documents)
            {
                Console.WriteLine(doc);
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool found = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
            }
        }
        if (found == false)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {

        bool found = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
            }
        }
        if (found == false)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool found = false;
        foreach (var doc in documents)
        {
            if (doc is IEncryptable)
            {
                found = true;
                ((IEncryptable)doc).Encrypt();
            }
        }
        if (found == true)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool docFound = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                docFound = true;
                if (doc is IEditable)
                {
                    ((IEditable)doc).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                }
            }
        }
        if (docFound == false)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }
}

namespace DocumentSystem_1
{
    public abstract class Documents : IDocument
    {

        public string Name
        {
            get;
            protected set;
        }

        public string Content
        {
            get;
            protected set;
        }

        protected readonly IList<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            if (key == "content")
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append("[");
            IList<KeyValuePair<string, object>> attributes = new List<KeyValuePair<string, object>>();
            SaveAllProperties(attributes);
            attributes = attributes.OrderBy(t => t.Key).ToList();
            foreach (var attr in attributes)
            {
                if (attr.Value != null)
                {
                    sb.Append(attr.Key);
                    sb.Append("=");
                    sb.Append(attr.Value);
                    sb.Append(";");
                }
            }
            sb.Length--;
            sb.Append("]");
            return sb.ToString();
        }
    }

    public abstract class BinaryDocument : Documents
    {
        public ulong? Size { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "size")
            {
                this.Size = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("size", this.Size));
            base.SaveAllProperties(output);
        }
    }

    public class TextDocument : Documents, IEditable
    {
        public string CharSet { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "charset")
            {
                this.CharSet = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("charset", this.CharSet));
            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }

    public abstract class MultimediaDocument : BinaryDocument
    {
        public int? Length { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "length")
            {
                this.Length = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("length", this.Length));
            base.SaveAllProperties(output);
        }
    }

    public abstract class EncryptableDocument : BinaryDocument, IEncryptable
    {

        private bool isEncrypted = false;

        public bool IsEncrypted
        {
            get { return isEncrypted; }
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }

        public override string ToString()
        {

            if (this.isEncrypted == true)
            {
                var sb = new StringBuilder();
                sb.Append(this.GetType().Name);
                sb.Append("[");
                sb.Append("encrypted");
                sb.Append("]");
                return sb.ToString();
            }
            else
            {
                return base.ToString();
            }
        }
    }

    public abstract class OfficeDocument : EncryptableDocument
    {
        public string Version { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "version")
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("version", this.Version));
            base.SaveAllProperties(output);
        }
    }

    public class PDFDocument : EncryptableDocument
    {
        public int? NumberOfPages { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.NumberOfPages = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));
            base.SaveAllProperties(output);
        }
    }

    public class WordDocument : OfficeDocument, IEditable
    {
        public ulong? NumberOfCharacters { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.NumberOfCharacters = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("chars", this.NumberOfCharacters));
            base.SaveAllProperties(output);
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }

    public class ExcelDocument : OfficeDocument
    {
        public int? NumberOfRows { get; set; }
        public int? NumberOfCols { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.NumberOfRows = int.Parse(value);
            }
            else if (key == "cols")
            {
                this.NumberOfCols = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfCols));
            base.SaveAllProperties(output);
        }
    }

    public class AudioDocument : MultimediaDocument
    {
        public int? SampleRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
            {
                this.SampleRate = int.Parse(value);
            }

            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
            base.SaveAllProperties(output);
        }
    }

    public class VideoDocument : MultimediaDocument
    {
        public int? FrameRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate")
            {
                this.FrameRate = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
            base.SaveAllProperties(output);
        }
    }
}
