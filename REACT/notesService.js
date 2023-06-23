import axios from 'axios';
import * as helper from '../services/serviceHelpers';


const endpoint = `${helper.API_HOST_PREFIX}/api/notes`;

const addNote = (payload) => {
    const config = {
        method: "POST",
        url: `${endpoint}`,
        data: payload,
        crossdomain: true,
        headers: { "Content-Type": "application/json"},
    };
    return axios(config).then(helper.onGlobalSuccess).catch(helper.onGlobalError);
};


const getNoteByLectureId = (lectureId) => {
    const config = {
        method: "GET",
        url: `${endpoint}/${lectureId}/current`,
        crossdomain: true,
        headers: { "Content-Type": "application/json"},
    };
    return axios(config).then(helper.onGlobalSuccess).catch(helper.onGlobalError);
};


const deleteNoteById = (id) => {
    const config = {
        method: "DELETE",
        url: `${endpoint}/${id}`,
        crossdomain: true,
        headers: { "Content-Type": "application/json" },
    };
    return axios(config);
};



export {addNote, getNoteByLectureId, deleteNoteById};