import * as Yup from "yup";


const notesSchema = Yup.object().shape({
    lectureNotes: Yup.string().min(10).max(4000).required("Is Required"),
  });
  

export default notesSchema;
