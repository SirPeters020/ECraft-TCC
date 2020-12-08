import React from 'react'
import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Box from '@material-ui/core/Box';
import { Link } from 'react-router-dom'


import Notifications from './Notifications'
import WritePost from './WritePost'
import Account from './Account'

const useStyles = makeStyles({
    appBar: {
        boxShadow: 'none'
    },
    img: {
        maxHeight: 55,
    },
    grow: {
        flexGrow: 1
    },
    userSection: {
        display: 'flex',
        alignItems: 'center'
    },
})

function Header() {
    const classes = useStyles()

    return (
        <AppBar position="fixed" className={classes.appBar}>
            <Toolbar>
                <Link to='/'>
                    <img src="/images/logo.png" alt="logo" className={classes.img} />
                </Link>
                <div className={classes.grow} />
                <div className={classes.userSection}>
                    <WritePost />
                </div>
                <Box ml={2} >
                    <Notifications />
                </Box>
                <Box ml={2} >
                    <Account />
                </Box>
            </Toolbar>
        </AppBar>
    )
}

export default Header