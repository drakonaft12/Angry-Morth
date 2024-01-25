using Birds;
using System.Collections;
using System.Threading;
using UnityEngine;


namespace Slingshots
{
    public class Slingshot : MonoBehaviour
    {
        [SerializeField] private BirdTransfer birdTransfer = new();
        [SerializeField] private float power = 10;
        [SerializeField] private float count = 3;
        [Header("Dependencies")] [SerializeField]
        private VorcsRogatka vorcsPoint = null!;
        [SerializeField] private BirdSpawn birdSource = null!;

        [SerializeField] MenuBase Menu;


        private IEnumerator Start()
        {
            for (int i = 0; i < count; i++)
            {
                var borb = birdSource.NextBird();
                yield return SeatBird(borb);
                yield return WaitShot(borb);
            }

            yield return new WaitForSecondsRealtime(5);
            Menu.StartScene("Menu");
                
        }


        private IEnumerator WaitShot(Bird bird)
        {
            var done = false;

            void Shot(Vector2 direction)
            {
                done = true;
                bird.Launch(direction * power);
            }

            vorcsPoint.onRelease!.AddListener(Shot);
            
            while (done == false)
            {
                bird.transform.position = vorcsPoint.transform.position;
                yield return null;
            }

            vorcsPoint.onRelease!.RemoveAllListeners();
        }


        private IEnumerator SeatBird(Bird bird)
        {
            vorcsPoint.enabled = false;
            yield return birdTransfer.Transfer(bird, vorcsPoint.transform.position);
            vorcsPoint.enabled = true;
        }
    }
}