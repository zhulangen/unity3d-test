using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;


public class test2 : MonoBehaviour
{



    private static Dictionary<string, State> defaultLayer =new Dictionary<string, State>();

    [MenuItem("AnimationClip/GetFilteredtoAnim")]

    static void GetFiltered()
    {
        UnityEngine.Object[] objs = Selection.GetFiltered (typeof(UnityEngine.Object), SelectionMode.DeepAssets);
        foreach (UnityEngine.Object _obj in objs)
        {
            if(_obj.name.EndsWith("_action")==false)
            {
                continue;
            }

            string path = AssetDatabase.GetAssetPath(_obj);
            string antrl = string.Format("{0}/Controller/{1}.controller",
                Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path).Replace("_action",""));

            if (!Directory.Exists(Path.GetDirectoryName(antrl)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(antrl));
            }
            AnimatorController animatorController = AnimatorController.CreateAnimatorControllerAtPath(antrl);
            //得到它的Layer， 默认layer为base 你可以去拓展
            AnimatorControllerLayer layer = animatorController.GetLayer(0);
            AnimatorControllerLayer beigongji  =animatorController.AddLayer("beigongji");


            AvatarMask am=new AvatarMask();
            

            animatorController.AddParameter("Speed", AnimatorControllerParameterType.Bool);
            animatorController.AddParameter("Die", AnimatorControllerParameterType.Trigger);
            animatorController.AddParameter("Drop", AnimatorControllerParameterType.Trigger);
            animatorController.AddParameter("Fire", AnimatorControllerParameterType.Trigger);
            animatorController.AddParameter("Hit", AnimatorControllerParameterType.Trigger);


            if (Path.GetExtension(path) == ".FBX")
            {
                UnityEngine.Object[] arr = AssetDatabase.LoadAllAssetsAtPath(path);
                foreach(Object j in arr)
                {
                    if(j.name.EndsWith("001"))
                    {
                        continue;
                    }
                    if (j is AnimationClip)
                    {
                        if(j.name=="beigongji")
                        {
                            CreateBeigongji(j as AnimationClip, beigongji);
                        }
                        else
                        {
                            AddStateTransition(j as AnimationClip, layer);
                        }
                        Debug.Log(path + "/" + j.name);
                    }
                }
            }
            AddDefaultCon(layer);
        }

        AssetDatabase.Refresh();
    }
    static void CreateBeigongji(AnimationClip newClip, AnimatorControllerLayer layer)
    {
        UnityEditorInternal.StateMachine sm = layer.stateMachine;

        State nullstate =sm.AddState("Null");
        sm.defaultState = nullstate;
        //根据动画文件读取它的AnimationClip对象
        State state = sm.AddState(newClip.name);
        state.SetAnimationClip(newClip, layer);

        Transition trans =sm.AddTransition(nullstate, state);
        trans.RemoveCondition(0);
        AnimatorCondition ac = trans.AddCondition();
        ac.parameter = "Hit";
        ac.mode = TransitionConditionMode.Less;
        trans =sm.AddTransition(state,nullstate);
        //把默认的时间条件删除
       
        
        
        

    }

    static  void AddStateTransition(AnimationClip newClip, AnimatorControllerLayer layer)
    {
        UnityEditorInternal.StateMachine sm = layer.stateMachine;
        //根据动画文件读取它的AnimationClip对象
        State state = sm.AddState(newClip.name);
        state.SetAnimationClip(newClip, layer);
        defaultLayer[state.name]=state;
        if(state.name=="xiajiang")
        {
            sm.defaultState = state;
        }

    }
    //添加状态条件
    static void AddDefaultCon(AnimatorControllerLayer layer)
    {
        UnityEditorInternal.StateMachine sm = layer.stateMachine;
        //xiajiang->luodi->tingzhi
        Transition trans = sm.AddTransition(defaultLayer["xiajiang"], defaultLayer["luodi"]);
        AnimatorCondition ac = trans.GetCondition(0);
        ac.parameter = "Drop";
        ac.mode = TransitionConditionMode.Less;
        sm.AddTransition(defaultLayer["luodi"], defaultLayer["tingzhi"]);
        trans=sm.AddTransition(defaultLayer["tingzhi"], defaultLayer["zou"]);
        ac = trans.GetCondition(0);
        ac.parameter = "Speed";
        ac.mode = TransitionConditionMode.IfNot;
        trans = sm.AddTransition(defaultLayer["zou"], defaultLayer["shache"]);
        ac = trans.GetCondition(0);
        ac.parameter = "Speed";
        ac.mode = TransitionConditionMode.If;
        sm.AddTransition(defaultLayer["shache"], defaultLayer["tingzhi"]);
        trans= sm.AddTransition(defaultLayer["tingzhi"], defaultLayer["gongji"]);
        ac = trans.GetCondition(0);
        ac.parameter = "Fire";
        ac.mode = TransitionConditionMode.If;
        sm.AddTransition(defaultLayer["gongji"], defaultLayer["tingzhi"]);

        trans = sm.AddTransition(defaultLayer["luodi"], defaultLayer["gongji"]);
        ac = trans.GetCondition(0);
        ac.parameter = "Fire";
        ac.mode = TransitionConditionMode.If;

        trans = sm.AddTransition(defaultLayer["zou"], defaultLayer["gongji"]);
        ac = trans.GetCondition(0);
        ac.parameter = "Fire";
        ac.mode = TransitionConditionMode.If;

        trans = sm.AddAnyStateTransition(defaultLayer["siwang"]);

        ac = trans.GetCondition(0);
        ac.parameter = "Die";
        ac.mode = TransitionConditionMode.Equals;
    }
}
