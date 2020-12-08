import React from 'react'
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Button from '@material-ui/core/Button'
import { makeStyles } from '@material-ui/core/styles'

import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { postContent } from '../../../../actions/postsActions'

import { usePost } from '../../../../context/PostContext'


const useStyles = makeStyles(() => ({
    root: {
    },
    appBar: {
        top: 'auto',
        bottom: 0,
        alignItems: 'center'
    },
    image: {
        height: 100
    },
}))

function BottomBar() {
    const classes = useStyles()
    const ctx = usePost()
    const { title, image, tags, type, markdownText } = ctx
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const handlePost = async () => {
        try {
            await dispatch(postContent(title, tags, type, markdownText));
            navigate('/');
        } catch (error) {
            const message = 'Alguma coisa aconteceu';
        }
    }

    return (
        <AppBar position="fixed" color="inherit" className={classes.appBar} >
            <Toolbar>
                <Button className={classes.button}>Salvar Rascunho</Button>
                <Button color="secondary" variant="outlined" onClick={handlePost} >PUBLICA</Button>
            </Toolbar>
        </AppBar >
    )
}

export default BottomBar