import React from 'react'
import { makeStyles } from '@material-ui/core/styles'
import Paper from '@material-ui/core/Paper'
import Button from '@material-ui/core/Button'
import ListSubheader from '@material-ui/core/ListSubheader'
import ListItem from '@material-ui/core/ListItem'
import ListItemText from '@material-ui/core/ListItemText'
import { useNavigate } from 'react-router-dom'
import { useSelector } from 'react-redux'

const useStyles = makeStyles((theme) => ({
    root: {
        padding: theme.spacing(2),
        width: '60%',
        marginRight: theme.spacing(2),
        height: '100%',
    },
    button: {
        width: '100%'
    }
}))

const tags = [
    { id: 1, tag: 'Croche' },
    { id: 2, tag: 'Bordado' },
    { id: 3, tag: 'Croche-Tunisiano' },
    { id: 4, tag: 'Skatchbook' },
    { id: 6, tag: 'Origami' },
    { id: 6, tag: 'Pintura com Agulha' },
]

function NavBar() {
    const classes = useStyles()
    const navigate = useNavigate()
    const account = useSelector((state) => state.account)
    const isAuthenticated = !!account.user

    return (
        <Paper className={classes.root}>
            {
                !isAuthenticated && 
                <Button variant="outlined" color="secondary" className={classes.button} onClick={() => navigate('/sign-up')}>Registrar Agora</Button>
            }
            <ListSubheader >{`Navegação`}</ListSubheader>
            {
                tags.map((item) => (
                    <ListItem dense button key={`item-${item.id}-${item.tag}`}>
                        <ListItemText primary={`#${item.tag}`} />
                    </ListItem>
                ))
            }
            <ListItem button>
                Exibir mais
            </ListItem>
        </Paper>
    )
}

export default NavBar;