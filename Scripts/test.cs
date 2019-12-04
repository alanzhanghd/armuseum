using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.UI;

namespace test {
    public class test : MonoBehaviour
    {
        [System.Serializable]
        public class NoteInfo
        {
            public float px;
            public float py;
            public float pz;
            public float qx;
            public float qy;
            public float qz;
            public float qw;
            public string note;
        }
        [SerializeField] Text mLabelText;

        [System.Serializable]
        public class NotesList
        {
            // List of all notes stored in the current Place.
            public NoteInfo[] notes;
        }
        /*
        public class NoteController : MonoBehaviour
        {
            // This is set to -1 when instantiated, and assigned when saving notes.
            [SerializeField] public int mIndex = -1;
            [SerializeField] public bool mActiveButtons = false;


            //public Button mEditButton;
            public Button mDeleteButton;

        }
        */

        public List<GameObject> mNotesObjList = new List<GameObject>();
        public List<NoteInfo> mNotesInfoList = new List<NoteInfo>();

        public GameObject mNotePrefab;

        // Start is called before the first frame update
        void Start()
        {
            LoadNotesJSON(ReadMapIDFromFile());
        }

        public void WriteMapIDToFile(string mapID)
        {
            string path = Application.persistentDataPath + "/metadata.txt";
            Debug.Log(path);
            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(mapID);
            writer.Close();
        }

        public JToken ReadMapIDFromFile()
        {
            string path = Application.persistentDataPath + "/metadata.txt";
            Debug.Log(path);
            /*
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read,
                                          FileShare.ReadWrite | FileShare.Delete);

            if (System.IO.File.Exists(path))
            {
                string content;
                using (StreamReader reader = new StreamReader(fs, Encoding.Unicode))
                {
                    content = reader.ReadToEnd();
                }
                JObject returnValue = JObject.Parse(content);
                Debug.Log(returnValue);
                return returnValue;
            }
            else
            {
                return null;
            }*/
            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject returnValue = (JObject)JToken.ReadFrom(reader);
                return returnValue;
            }
        }

        public GameObject NoteFromInfo(NoteInfo info)
        {
            GameObject note = Instantiate(mNotePrefab);
            note.transform.position = new Vector3(info.px, info.py, info.pz);
            note.transform.rotation = new Quaternion(info.qx, info.qy, info.qz, info.qw);
            note.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            note.SetActive(true);

            // add listeners to the buttons
            //note.GetComponent<NoteController>().mEditButton.onClick.AddListener(OnEditButtonClick);
            //note.GetComponent<NoteController_new>().mDeleteButton.onClick.AddListener(OnDeleteButtonClick);


            //note.GetComponent<NoteController>().mEditButton.gameObject.SetActive(false);
            //note.GetComponent<NoteController_new>().mDeleteButton.gameObject.SetActive(false);
            note.GetComponent<NoteController_new>().mActiveButtons = false;

            //note.GetComponentInChildren<InputField>().text = info.note;

            return note;
        }

        public void OnDeleteButtonClick()
        {
            Debug.Log("Delete button clicked!");
            return;
        }

        public void LoadNotesJSON(JToken mapMetadata)
        {

            if (mapMetadata is JObject && mapMetadata["notesList"] is JObject)
            {
                NotesList notesList = mapMetadata["notesList"].ToObject<NotesList>();
                Debug.Log("length of notes " + notesList.notes.Length);
                mLabelText.text = "length of notes " + notesList.notes.Length;
                if (notesList.notes == null)
                {
                    Debug.Log("No notes created!");
                    return;
                }
                Debug.Log(notesList.notes);
                int i = 0;
                foreach (var noteInfo in notesList.notes)
                {
                    Debug.Log("px" + noteInfo.px + "," + noteInfo.py);
                    mLabelText.text = "Order: " + i;
                    i++;
                    GameObject note = NoteFromInfo(noteInfo);
                    //Debug.Log("objlist" + mNotesObjList.Count);
                    note.GetComponent<NoteController_new>().mIndex = mNotesObjList.Count;

                    mNotesObjList.Add(note);
                    mNotesInfoList.Add(noteInfo);

                }
            }
        }
    }
}