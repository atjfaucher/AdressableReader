using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DemoManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        var initOp = Addressables.InitializeAsync();
        yield return initOp;

        var loadCatalogOp = Addressables.LoadContentCatalogAsync("https://s3.us-east-1.amazonaws.com/assets.arcane-technologies.com/vortekspaces/Unity6_HDRP/dev/AAATestAddressables/catalog_0.1.0.hash");
        yield return loadCatalogOp;

        var op = Addressables.LoadAssetAsync<GameObject>("bbqs_kamadogrill_anim");
        yield return op;

        if (op.Status == AsyncOperationStatus.Succeeded)
        {
            var obj = op.Result;
            Instantiate(obj, transform);
        }
    }
}
