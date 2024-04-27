using UnityEngine;
using UnityEngine.UI;

public class EscurecerTelaScript : MonoBehaviour
{
    public RawImage imagemEscurecida; // Referência ao RawImage que cobre a tela

    private float delayParaEscurecer = 10f; // Delay em segundos para o escurecimento
    private float intensidadeMaxima = 1f; // Intensidade máxima de escurecimento (0 = transparente, 1 = completamente escuro)

    private float tempoInicial;
    private bool ativarEscurecimento = false; // Controla se o escurecimento está ativo
    private Color corOriginal;

    void Start()
    {
        
        tempoInicial = Time.time; // Inicializa o tempo inicial
        corOriginal = imagemEscurecida.color;
        
    }

    void Update()
    {
        if (ativarEscurecimento && imagemEscurecida != null)
        {
        
            float tempoDecorrido = Time.time - tempoInicial;
            float proporcao = Mathf.Clamp01(tempoDecorrido / delayParaEscurecer);
            float intensidadeAtual = Mathf.Lerp(0f, intensidadeMaxima, proporcao);

            Color corAtual = imagemEscurecida.color;
            corAtual.a = intensidadeAtual;
            imagemEscurecida.color = corAtual;

            if (intensidadeAtual >= intensidadeMaxima)
            {
                
                if(tempoDecorrido >= delayParaEscurecer + 2){ 
                imagemEscurecida.color = corOriginal;
                ativarEscurecimento = false; // Desativa o escurecimento após atingir a intensidade máxima
                }
            }
        }
    }

    public void IniciarEscurecimento(float delayParaEscurecer, float intensidadeMaxima)
    {
        if (!ativarEscurecimento) // Garante que o escurecimento não esteja em andamento
        {
            
            this.delayParaEscurecer = delayParaEscurecer;
            this.intensidadeMaxima = intensidadeMaxima;
            tempoInicial = Time.time; // Reinicia o tempo inicial
            ativarEscurecimento = true; // Ativa o escurecimento
        }
    }
}
