import axios from '../utils/axios';

class AuthService {
    signIn = (email, password) => {
        return new Promise((resolve, reject) => {
            axios
            .post('/v1/auth/login', { email, password }) // envia token pelo header
                .then((response) => {
                    if (response.data.user) {
                        this.setToken(response.data.token)
                        resolve(response.data.user)
                    } else {
                        reject(response.data.error)
                    }
                })
                .catch(error => {
                    reject(error)
                })
        })
    }

    signUp = (name, email, password) => {
        return new Promise((resolve, reject) => {
            axios
            .post('/v1/auth/register', { name, email, password }) // envia token pelo header
                .then((response) => {
                    if (response.data.user) {
                        this.setToken(response.data.token)
                        resolve(response.data.user)
                    } else {
                        reject(response.data.error)
                    }
                })
                .catch(error => {
                    reject(error)
                })
        })
    }

    signInWithToken = () => {
        return new Promise((resolve, reject) => {
            axios.post('/api/home/login') // envia token pelo header
                .then((response) => {
                    if (response.data.user) {
                        this.setToken('JWT')
                        resolve(response.data.user)
                    } else {
                        reject(response.data.error)
                    }
                })
                .catch(error => {
                    reject(error)
                })
        })
    }

    signOut = () => {
        this.removeToken()
    }

    setToken = (token) => {
        if(token){
            localStorage.setItem('accessToken', token)
            axios.defaults.headers.common.Authorization = `Bearer ${token}`
        } else {
            localStorage.removeItem('token')
            delete axios.defaults.headers.common.Authorization
        }
    }

    getToken = () => localStorage.getItem('accessToken')

    removeToken = () => localStorage.removeItem('accessToken')

    isAuthenticated = () => {
        return !!this.getToken();
    }

}

const authService = new AuthService()

export default authService