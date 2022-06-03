using UnityEngine;

public class CubeCtrl : MonoBehaviour
{
    public float moveSpeed = 15.0f;     // 이동 속도 변수 : public으로 선언되어 inspector 창에 노출된다. 
    public float turnSpeed = 80.0f;     // 회전 속도 변수 : public으로 선언되어 inspector 창에 노출된다. 
    
    private float h;    
    private float v;

    // 프레임마다 호출되는 함수, 화면의 렌더링 주기와 일치, 호출간격이 불규칙적임
    private void Update()
    {
        // InputManager의 Horizontal과 Vertical에 미리 설정된 값
        h = Input.GetAxis("Horizontal");  // -1.0f ~ 1.0f : (A,D)(Right, Left)
        v = Input.GetAxis("Vertical");     // -1.0f ~ 1.0f: (W,S)(Up, Down)

        Move();
    }

    private void Move()
    {
        // Translate 함수를 사용한 이동 로직 Translate(이동방향 * 속력 * Time.deltaTime * v)
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * v);
        // Rotate 함수를 사용한 이동로직 Rotate(회전축 * 속력 * Time.deltaTime * h)
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * h);
        
        /*
        <Time.deltaTime>
        Time.deltaTime을 곱하지 않으면 프레임당 지정한 유닛만큼 이동하거나 회전하게 되는데, 
        만약 사용자마다 컴퓨터의 사양이 달라 A의 컴퓨터는 초당 10프레임이, B의 컴퓨터는 초당 100프레임이 돌아간다면,
        초당 10m 간다고 지정하였을 때, A의 컴퓨터에서는 플레이어가 1초에 10미터 이동하는 현상이, B컴퓨터에서는 초당 100미터 이동하는 현상이 발생한다.
        이와 같은 현상을 막고, 어느 사양의 컴퓨터에서건 일정하게 초당 지정한 유닛만큼 이동하기 위해 Time.deltaTime을 곱해준다. 
        */
    }

    // 충돌이 시작할 때 발생하는 이벤트
    private void OnCollisionEnter(Collision coll)
    {
        // 충돌한 콜라이더의 오브젝트에 할당된 태그명 확인
        if (coll.collider.CompareTag("DUM"))
        {
            // 충돌한 콜라이더의 게임 오브젝트 삭제
            Destroy(coll.gameObject);
        }
    }
}
