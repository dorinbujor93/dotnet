class FileEncryptor
{
    private string filename;
    private EncryptStrategy strategy;

    public FileEncryptor(string filename, EncryptStrategy strategy)

    {
        this.filename = filename;
        this.strategy = strategy;
    }

    public void Encrypt()
    {
        this.strategy.Encrypt(filename);
    }
}