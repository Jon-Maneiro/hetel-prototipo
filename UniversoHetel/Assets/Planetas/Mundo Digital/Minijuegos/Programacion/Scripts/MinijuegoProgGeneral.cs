using UnityEngine;

namespace Planetas.Mundo_Digital.Minijuegos.Programacion.Scripts
{
    /*
     * Clase con metodos generales para el minijuego de Programación
     */
    public class MinijuegoProgGeneral : MonoBehaviour
    {
        /*
         * "Activa" el objeto "salida"
         * Mueve el objeto "salida" a z:0 (manteniendo el x,y de "pos")
         * Cambia el color de los materiales del "renderer" indicados en "renderPos" a verde
         */
        public static void ActivarSalida(GameObject salida, Vector3 pos, Renderer renderer, int[] renderPos, Color col)
        {
            salida.transform.position = pos;
            foreach (var posi in renderPos)
            {
                renderer.materials[posi].color = col;
            }
        }

        /*
         * "Desactiva" el objeto "salida"
         * Mueve el objeto "salida" a z:-500 (manteniendo el x,y de "pos")
         * Cambia el color de los materiales del "renderer" indicados en "renderPos" a rojo
         */
        public static void DesactivarSalida(GameObject salida, Vector3 pos, Renderer renderer, int[] renderPos, Color col)
        {
            pos = new Vector3(pos.x, pos.y, -500);
            salida.transform.position = pos;
            foreach (var posi in renderPos)
            {
                renderer.materials[posi].color = col;
            }
        }
    }
}
