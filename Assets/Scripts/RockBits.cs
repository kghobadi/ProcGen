using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBits : Interactable {
    
	
	void Update () {
        transform.Rotate(0, 1, 0 * Time.deltaTime);

    }

    public override void handleClickSuccess()
    {
        base.handleClickSuccess();
        Destroy(gameObject);
        _player.GetComponent<FirstPersonController>().rockCounter++;
    }

}
