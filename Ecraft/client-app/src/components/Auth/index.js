import { useEffect, useCallback } from 'react';
import { useDispatch } from 'react-redux'

import { setUserData } from '../../actions/accountActions'
import authService from '../../service/authService'

function Auth({children}) {
    const dispatch = useDispatch()
    const initAuth = useCallback(async () => {
        if(authService.isAuthenticated()){
            //recuperar dados de user logado
            await dispatch(setUserData())
        }
    }, [dispatch])

    useEffect(() => {
        initAuth()
    }, [initAuth])
    return children
}

export default Auth