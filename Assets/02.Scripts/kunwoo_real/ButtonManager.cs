﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public GameObject canvasClearBtn;
    [SerializeField]
    MyAgent myAgent;

    [SerializeField]
    private GameObject Temp;        //회전 테이블 자식의 위치를 이용하기 위함
    [SerializeField]
    private GameObject ColorTable;  //회전 테이블 객체
    [SerializeField]
    private GameObject particleEvent;   //파티클
    [SerializeField]
    private GameObject PrinterparticlePos01;   //파티클 위치
    [SerializeField]
    private GameObject PrinterparticlePos02;   //파티클 위치


    void Start() { }

    void Update() { }

    public void ClickImageButton() {
        Debug.Log("이미지 인식버튼");
        myAgent.isImgCheck = true;

        float[] testVal = { 2.0f};
        myAgent.AgentAction(testVal,"Test");
    }

    public void ClickCheckEndButton() {
        Debug.Log("종료버튼");
        myAgent.isEndPy = false;
    }

    public void ClickOutObject() {


        StartCoroutine(PrintObjectCo());


    }


    public void CanvasClear(){
        StartCoroutine(CanvasClearCo());
    }

    /// <summary>
    /// CanvasClearCo   : 그림판 지우기 기능
    /// PrintObjectCo
    /// </summary>

    IEnumerator CanvasClearCo(){
        
        canvasClearBtn.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        canvasClearBtn.SetActive(false);

    }

    IEnumerator PrintObjectCo()
    {
        // 효과 발동
        GameObject printParticle01 = Instantiate(particleEvent, PrinterparticlePos01.transform);
        Destroy(printParticle01, 3);

        yield return new WaitForSeconds(2f);

        Destroy(myAgent.printObjectShaderApply);

        GameObject printParticle02 = Instantiate(particleEvent, PrinterparticlePos02.transform);
        Destroy(printParticle02, 3);

        yield return new WaitForSeconds(2f);

        myAgent.tabletDontTouch.SetActive(false);
        myAgent.printButton.gameObject.SetActive(false);
        myAgent.GaugeImage.fillAmount = 0f;

        /*  출력물을 이제 어디에 위치해야 하는지 지정  */
        myAgent.printObject.transform.position = Temp.transform.position;
        myAgent.printObject.transform.parent = ColorTable.transform;
        myAgent.printObject.SetActive(true);

    }
}
