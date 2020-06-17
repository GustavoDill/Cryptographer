namespace Cryptographer
{
    public class CollectionDisplayObject
    {
        public static implicit operator CollectionDisplayObject(string v)
        {
            return new CollectionDisplayObject(v);
        }
        public static implicit operator string(CollectionDisplayObject v)
        {
            return v.Text;
        }
        public CollectionDisplayObject() => Text = "";
        public CollectionDisplayObject(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}