using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamarAlSingleton : MonoBehaviour
{   
    
    //no se puede poner el singleton en un botton porque desaparece asi que hace falta esta chorrada de script en los bottones para que lo llame
    
    public void changeHat(int id) {
        CosmeticosSingleton.instance.changeHat(id);
    }
    
    public void changesticker(int id) {
        CosmeticosSingleton.instance.changesticker(id);
    }
}
