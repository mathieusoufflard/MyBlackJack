namespace MyBlackJackXamarinForms
{
    class Card
    {
        public int Value { get; set; }
        public string Path { get; set; }

        public Card(int value, string path)
        {
            Value = value;
            Path = path;
        }
    }
}
