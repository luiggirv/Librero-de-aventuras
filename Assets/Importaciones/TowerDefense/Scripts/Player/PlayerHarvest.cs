using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to harvest fruits from <see cref="BushFruits"/>
/// </summary>
public class PlayerHarvest : MonoBehaviour
{
    [SerializeField] float harvestRadius;
    [SerializeField] float harvestTime;
    [SerializeField] LayerMask bushesMask;

    PlayerMovement playerMovement;
    PlayerBackpack backpack;
    AudioSource audioSource;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        backpack = GetComponent<PlayerBackpack>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            TryHarvestClose();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<BushFruits>()) {
                    if (!backpack.isMax())
                    {
                        BushFruits bush = hit.collider.GetComponent<BushFruits>();
                        if (bush.HasFruits())
                        {
                            Debug.Log("cosechando");
                            audioSource.Play();
                            playerMovement.HarvestStopMovement(harvestTime);
                            backpack.AddFruits(bush.HarvestFruit());
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Harvesting is done in 2 parts: first, it tries to harvest really close bushes to guarantee that if the player harvests near 2 bushes,
    /// it will always harvest the closest one.
    /// <para>Then, if nothing was harvested in a close radius, it tries to harvest in the normal radius with <see cref="TryHarvestFruit"/></para>
    /// </summary>
    void TryHarvestClose()
    {
        //Collider2D hit =
        //Physics2D.OverlapCircle(transform.position, harvestRadius / 2, bushesMask);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        //if (hit.collider != null)
        //{
        //    BushFruits bush = hit.collider.GetComponent<BushFruits>();
        //    if (bush.HasFruits())
        //    {
        //        audioSource.Play();
        //        playerMovement.HarvestStopMovement(harvestTime);
        //        backpack.AddFruits(bush.HarvestFruit());
        //    }
        //}
        //else
        //{
        //    TryHarvestFruit();
        //}
    }
    void TryHarvestFruit()
    {
        //Collider2D hit =
        //Physics2D.OverlapCircle(transform.position, harvestRadius,bushesMask);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            BushFruits bush = hit.collider.GetComponent<BushFruits>();
            if (bush.HasFruits())
            {
                audioSource.Play();
                playerMovement.HarvestStopMovement(harvestTime);
                backpack.AddFruits(bush.HarvestFruit());
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, harvestRadius);
    }
}
