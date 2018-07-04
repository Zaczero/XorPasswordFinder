namespace XORdecryptor
{
    public static class XOR
    {
        public static char EncryptDecrypt(char i, char k)
        {
            return (char) (i ^ k);
        }
    }
}
