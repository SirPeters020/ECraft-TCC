import axios from '../utils/axios'

const postContent = (title, tags, type, markdownText) => {
    return async (dispatch) => {
        const postDestiny = `/api/${type}`
        await axios.post(postDestiny, {title, tags, markdownText})
    }
}

export { postContent }