using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorManager : MonoSingleton<ChangeColorManager>
{
    [SerializeField] private SkinnedMeshRenderer player;
    private Material desiredMaterial;
    private Material initialMaterial;
    [SerializeField] private float blendTime;
    private float currentTime;

    private void Start()
    {
        desiredMaterial = player.material;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.material != desiredMaterial)
        {
            player.material.Lerp(initialMaterial, desiredMaterial, currentTime/blendTime);
            currentTime += Time.deltaTime;
        }
    }

    public void StartChange(Material material)
    {
        desiredMaterial = material;
        initialMaterial = player.material;
    }
}
