using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    
    public class EnemyMovement : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}


		float getPlayerDistance(GameObject player){
			float distance = Vector3.Distance (transform.position, player.transform.position);
			return distance;
    	}

		GameObject findNearestPlayer(GameObject[] players){
			if(players == null){
				return null;
			}

			GameObject player = null;

			float bestDistance = 0;
			for(int i = 0; i < players.Length; i++){
				float distance = getPlayerDistance(players[i]);

				if(player == null){
					bestDistance = distance;
					player = players[i];
				} else if(bestDistance > distance){
					bestDistance = distance;
					player = players[i];
				}
			}
			return player;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        	GameObject closetPlayer = findNearestPlayer(players);
            
			target = closetPlayer.transform;
			if (target != null && ai != null) ai.destination = target.position;
		}
    }
}
