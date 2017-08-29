using UnityEngine;
using System.Collections;

public class EnemyBulletMove1 : AbstractEnemyBullet {
    
    public override void SetStart() {
        r2d.velocity = speed * direction;
    }
}
