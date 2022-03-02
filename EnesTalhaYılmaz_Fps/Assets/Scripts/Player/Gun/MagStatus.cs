using UnityEngine;

namespace EnesTalhaYılmaz_Fps.Gun{
public class MagStatus : MonoBehaviour
{
    [SerializeField] int magazineCap=10;
    private int currentAmmo=10;

    public int MagazineCap   // property
    {
        get { return magazineCap; }
        set { magazineCap = value; }
    }
    public int CurrentAmmo   // property
    {
        get { return currentAmmo; }
        set { currentAmmo = value; }
    }
    void Awake(){
        currentAmmo=magazineCap;
    }
    public bool MagazineStatus(){
        if(currentAmmo>0){
                currentAmmo--;
                return false;
            }
            else{

                Debug.Log("Empty Magazine");
                return true;
            }
    }
}
}

