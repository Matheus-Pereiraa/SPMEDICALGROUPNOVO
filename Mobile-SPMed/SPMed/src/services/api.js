import axios from 'axios';

const api  = axios.create({
    baseURL: 'http://192.168.5.202:5000'
})

export default api  