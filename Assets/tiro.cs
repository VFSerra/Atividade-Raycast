using UnityEngine;

public class Shoot : MonoBehaviour
{
    Ray ray;
    RaycastHit hitData;
    Color color;
    public Material vermeio;
    public Material azulao;
    public Material verdecara;
    public Camera _camera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray raioponto = Camera.main.ScreenPointToRay(Input.mousePosition); //raycast na posição do mouse no momento de execução
            color = Color.red;
            Tiro(vermeio);
        }

        if (Input.GetMouseButtonDown(1)) { //raycast com distância setada
            ray = new Ray(transform.position, transform.forward);
            color = Color.green;
            Tiro(verdecara);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift)) { //raycast associado com a camera
            ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
            color = Color.blue;
            Tiro(azulao);
        }

    }
    public void Tiro(Material materialBacana) {
        
        Vector3 origem = transform.position;
        Vector3 direcao = transform.forward;
        RaycastHit hit;
        float distanciaMax = Mathf.Infinity;
        Debug.DrawRay(origem, direcao * distanciaMax, color);


        if (Physics.Raycast(origem, direcao, out hit, distanciaMax))
        {
            Debug.Log("Você coloriu: " + hit.transform.name);

            Renderer rend = hit.collider.GetComponent<Renderer>();
            /*
            hit.collider.GetComponent<Renderer>().material = vermeio;
            hit.collider.GetComponent<Renderer>().material = azulao;
            hit.collider.GetComponent<Renderer>().material = verdecara; */

            if (rend != null && materialBacana != null)
            {
                rend.material = materialBacana;
                Debug.Log("Material de " + hit.collider.name + " alterado!");
            }
            Target target = hit.collider.GetComponent<Target>();
            if (target != null)
            {
                target.Hit();
            }


        }
    }
  

}

    
    

   
  

