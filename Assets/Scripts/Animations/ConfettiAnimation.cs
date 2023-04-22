using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem anim1;
    public ParticleSystem anim2;
    public ParticleSystem anim3;
    public ParticleSystem anim4;
    public ParticleSystem anim5;
    void Start()
    {

    }

    public void playAnimation()
    {
        Instantiate(anim1);
        Instantiate(anim2);
        Instantiate(anim3);
        Instantiate(anim4);
        Instantiate(anim5);
    }
    public void stopAnimation()
    {
        anim1.Stop();
        anim2.Stop();
        anim3.Stop();
        anim4.Stop();
        anim5.Stop();
    }
}
