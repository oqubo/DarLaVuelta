using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CajeroController : MonoBehaviour
{

    [SerializeField] private int limiteMaximoPrecioPedido, incrementoLimiteMaximoPrecioPedido, despisteCliente, incrementoDespisteCliente, clientesSuperados;

    [SerializeField] private int precioTotal, dineroRecibido, cambio, desfase, vidas;
    
    [SerializeField] private TextMeshProUGUI precioTotalText, dineroRecibidoText, cambioText, clientesSuperadosText;

    [SerializeField] private Image barraVida;

    [SerializeField] private GameObject canvasGameOver;
    [SerializeField] private TextMeshProUGUI recordText;
    
    [SerializeField] private int cantidad1cts,
        cantidad2cts,
        cantidad5cts,
        cantidad10cts,
        cantidad20cts,
        cantidad50cts,
        cantidad1e,
        cantidad2e,
        candidad5e,
        cantidad10e,
        candidad20e,
        cantidad50e;
    

    
    [SerializeField] private TextMeshProUGUI cantidad1ctsText,
        cantidad2ctsText,
        cantidad5ctsText,
        cantidad10ctsText,
        cantidad20ctsText,
        cantidad50ctsText,
        cantidad1eText,
        cantidad2eText,
        candidad5eText,
        cantidad10eText,
        candidad20eText,
        cantidad50eText;
    

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidas = 10;
        desfase = 0;
        despisteCliente = 0;
        limiteMaximoPrecioPedido = 10000;
        clientesSuperados = 0;
        NuevoCliente();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NuevoCliente()
    {
        despisteCliente += incrementoDespisteCliente; // Despiste del cliente
        precioTotal = Random.Range(100, limiteMaximoPrecioPedido); // Precio total entre 1 y 100 euros
        dineroRecibido = Random.Range(precioTotal, precioTotal + despisteCliente); // Dinero recibido 
        Debug.Log("diferencia: " + (dineroRecibido - precioTotal));
        cambio = 0;
        ReiniciarMonedas();
        ActualizarTextos();
    }

    public void AnadirMoneda(int valor)
    {
        cambio += valor;
        ActualizarCantidadMonedas(valor);
        ActualizarTextos();
    }
    
    void ActualizarCantidadMonedas(int valor)
    {
        switch(valor)
        {
            case 1:
                cantidad1cts++;
                break;
            case 2:
                cantidad2cts++;
                break;
            case 5:
                cantidad5cts++;
                break;
            case 10:
                cantidad10cts++;
                break;
            case 20:
                cantidad20cts++;
                break;
            case 50:
                cantidad50cts++;
                break;
            case 100:
                cantidad1e++;
                break;
            case 200:
                cantidad2e++;
                break;
            case 500:
                candidad5e++;
                break;
            case 1000:
                cantidad10e++;
                break;
            case 2000:
                candidad20e++;
                break;
            case 5000:
                cantidad50e++;
                break;
        }
    }
    
    void ReiniciarMonedas()
    {
        cantidad1cts = 0;
        cantidad2cts = 0;
        cantidad5cts = 0;
        cantidad10cts = 0;
        cantidad20cts = 0;
        cantidad50cts = 0;
        cantidad1e = 0;
        cantidad2e = 0;
        candidad5e = 0;
        cantidad10e = 0;
        candidad20e = 0;
        cantidad50e = 0;

        ActualizarTextos();
    }
    
    public void AceptarPago()
    {
        clientesSuperados++;
        // valor absoluto de la diferencia entre dinero recibido y precio total
        desfase += Mathf.Abs(precioTotal + cambio - dineroRecibido);
        if (desfase > 0) vidas--;
        Debug.Log("vidas: " + vidas);
        if (vidas <= 0) GameOver();
        ActualizarTextos();
        NuevoCliente();
    }

    void GameOver()
    {
        canvasGameOver.SetActive(true);
        recordText.text = clientesSuperados.ToString();
    }
    
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ActualizarTextos()
    {
        barraVida.fillAmount = (float)vidas / 10;
        
        // formato euros , centimos con dos decimales
        
        clientesSuperadosText.text = clientesSuperados.ToString();
        
        precioTotalText.text = (precioTotal/100).ToString() + "," + valorModulo(precioTotal) + " €";
        
        dineroRecibidoText.text = (dineroRecibido/100).ToString() + "," + valorModulo(dineroRecibido) + " €";
        cambioText.text = (cambio/100).ToString() + "," + valorModulo(cambio) + " €";

        cantidad1ctsText.text = cantidad1cts.ToString();
        cantidad2ctsText.text = cantidad2cts.ToString();
        cantidad5ctsText.text = cantidad5cts.ToString();
        cantidad10ctsText.text = cantidad10cts.ToString();
        cantidad20ctsText.text = cantidad20cts.ToString();
        cantidad50ctsText.text = cantidad50cts.ToString();
        cantidad1eText.text = cantidad1e.ToString();
        cantidad2eText.text = cantidad2e.ToString();
        candidad5eText.text = candidad5e.ToString();
        cantidad10eText.text = cantidad10e.ToString();
        candidad20eText.text = candidad20e.ToString();
        cantidad50eText.text = cantidad50e.ToString();
    }

    string valorModulo(int valor)
    {
        string resultado = "";
        int modulo = valor % 100; // Calcula el modulo 100
        if (modulo < 10) // Si el modulo es negativo, lo ajusta para que sea positivo
        {
            resultado = "0" + modulo.ToString();
        }
        else
        {
            resultado = modulo.ToString();
        }
        return resultado;
    }


}
