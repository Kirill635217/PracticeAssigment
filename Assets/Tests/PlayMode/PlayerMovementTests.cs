using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class PlayerMovementTests
    {
        [UnityTest]
        public IEnumerator MoveForward()
        {
            var player = new GameObject().AddComponent<PlayerDummy>();
            player.SetMoveDirection(Vector3.forward);
            yield return new WaitForSeconds(0.2f);
            Assert.AreEqual(true, Vector3.Distance(new Vector3(0, 0, player.Speed * 0.2f), player.transform.position) < .1f);
        }

        [UnityTest]
        public IEnumerator MoveBackward()
        {
            var player = new GameObject().AddComponent<PlayerDummy>();
            player.SetMoveDirection(Vector3.back);
            yield return new WaitForSeconds(0.2f);
            Assert.AreEqual(true, Vector3.Distance(new Vector3(0, 0, -player.Speed * 0.2f), player.transform.position) < .1f);
        }

        [UnityTest]
        public IEnumerator MoveLeft()
        {
            var player = new GameObject().AddComponent<PlayerDummy>();
            player.SetMoveDirection(Vector3.left);
            yield return new WaitForSeconds(0.2f);
            Assert.AreEqual(true, Vector3.Distance(new Vector3(-player.Speed * 0.2f, 0, 0), player.transform.position) < .1f);
        }

        [UnityTest]
        public IEnumerator MoveRight()
        {
            var player = new GameObject().AddComponent<PlayerDummy>();
            player.SetMoveDirection(Vector3.right);
            yield return new WaitForSeconds(0.2f);
            Assert.AreEqual(true, Vector3.Distance(new Vector3(player.Speed * 0.2f, 0, 0), player.transform.position) < .1f);
        }
    }
}