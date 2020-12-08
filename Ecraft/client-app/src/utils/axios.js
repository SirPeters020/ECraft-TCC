import axios from 'axios';

const instance = axios.create({
    baseURL: 'https://localhost:44313',
    responseType : 'json',
});

export default instance