namespace aula_03;

public class Televisao
{
    private const float TAMANHO_MINIMO = 22;
    private const float TAMANHO_MAXIMO = 80;
    private const int VOLUME_MAXIMO = 12;
    private const int VOLUME_MINIMO = 0;
    private const int VOLUME_PADRAO = 10;

    private int _ultimoVolume = VOLUME_PADRAO;

    // Construtor
    public Televisao(float tamanho)
    {
        if (tamanho < TAMANHO_MINIMO || tamanho > TAMANHO_MAXIMO)
        {
            throw new ArgumentOutOfRangeException($"O tamanho({tamanho}) não é suportado!");
        }
        Tamanho = tamanho;
        Volume = VOLUME_PADRAO;
        Canal = 1; // Canal inicial padrão
    }

    // Propriedades
    public float Tamanho { get; }
    public int Volume { get; private set; }
    public int Canal { get; set; }
    public bool Estado { get; set; }

    // Aumentar volume
    public void AumentarVolume()
    {
        if (Volume == VOLUME_MINIMO) // Se está no modo mudo
        {
            Console.WriteLine("Não é possível alterar o volume enquanto estiver no modo mudo.");
            return;
        }

        if (Volume < VOLUME_MAXIMO)
        {
            Volume++;
            _ultimoVolume = Volume;
        }
        else
        {
            Console.WriteLine("A TV já está no volume máximo permitido.");
        }
    }

    // Diminuir volume
    public void DiminuirVolume()
    {
        if (Volume == VOLUME_MINIMO) // Se está no modo mudo
        {
            Console.WriteLine("Não é possível alterar o volume enquanto estiver no modo mudo.");
            return;
        }

        if (Volume > VOLUME_MINIMO)
        {
            Volume--;
            _ultimoVolume = Volume;
        }
        else
        {
            Console.WriteLine("A TV já está no volume mínimo permitido.");
        }
    }

    // Alternar o modo mudo
    public void AlternarModoMudo()
    {
        if (Volume > VOLUME_MINIMO)
        {
            _ultimoVolume = Volume;
            Volume = VOLUME_MINIMO;
            Console.WriteLine("A TV está no modo MUTE.");
        }
        else
        {
            Volume = _ultimoVolume;
            Console.WriteLine($"O volume da TV foi restaurado para: {Volume}.");
        }
    }

    // Mudar para um canal específico
    public void MudarCanal(int novoCanal)
    {
        if (novoCanal < 1 || novoCanal > 999)
        {
            throw new ArgumentOutOfRangeException("O canal deve estar entre 1 e 999.");
        }
        Canal = novoCanal;
    }

    // Aumentar canal
    public void AumentarCanal()
    {
        if (Canal < 999)
        {
            Canal++;
        }
    }

    // Diminuir canal
    public void DiminuirCanal()
    {
        if (Canal > 1)
        {
            Canal--;
        }
    }
}