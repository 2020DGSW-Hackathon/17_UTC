using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

	public GameObject tutorial_UI;
	public GameObject player;
	public Text main_text;
	public Text sub_text;
	
	int order = 0;

	private string[] main = new string[6] {"이동 W/A/S/D", "블록에 접촉하고 H를 눌러 블럭을 이동시킬 수 있습니다.", "블럭을 들고 다른 블럭과 접촉하면 블럭들이 연결됩니다.", "블럭의 위치를 수정할 때도 아까와 같은 방법을 사용하시면 됩니다.", "모든 블럭들을 올바른 순서로 조합하면 스테이지가 클리어 됩니다.", ""};
	private string[] sub = new string[1] {"스페이스 바를 누르시면 다음 설명이 출력됩니다."};

    private void Start()
    {
		player.SetActive(false);
    }

    void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			Tutorial_Next();
		}
	}

	public void Tutorial_Next() {
		main_text.text = main[order];
		order += 1;
		if(order == 6){
			tutorial_UI.SetActive(false);
			player.SetActive(true);
		}
	}
}