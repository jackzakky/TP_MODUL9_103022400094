using System;
using System.IO;
using System.Text.Json;

public class Config
{
    public string satuan_suhu { get; set; }
    public int batas_hari_deman { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public Config() { } 
}

public class CovidConfig
{
    public Config config;
    private const string path = "covid_config.json";

    public CovidConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch
        {
            SetDefault();
            WriteConfigFile();
        }
    }

    
    private void SetDefault()
    {
        config = new Config
        {
            satuan_suhu = "celcius",
            batas_hari_deman = 14,
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
        };
    }

    private void ReadConfigFile()
    {
        string jsonString = File.ReadAllText(path);
        config = JsonSerializer.Deserialize<Config>(jsonString);
    }

    private void WriteConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(path, jsonString);
    }

    
    public void UbahSatuan()
    {
        if (config.satuan_suhu == "celcius")
        {
            config.satuan_suhu = "fahrenheit";
        }
        else
        {
            config.satuan_suhu = "celcius";
        }
    }
}