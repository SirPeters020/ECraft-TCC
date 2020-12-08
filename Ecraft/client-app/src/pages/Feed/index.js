import React, { useState, useCallback, useEffect } from 'react'
import { makeStyles } from '@material-ui/core/styles'
import PostCard from '../../components/PostCard'
import Container from '@material-ui/core/Container'
import Box from '@material-ui/core/Box'

import axios from '../../utils/axios'
import NavBar from './NavBar'
import Axios from 'axios'

const useStyles = makeStyles((theme) => ({
    root: {},
    navbar: {
        [theme.breakpoints.down('sm')] : {
            display: 'none',
        }
    }
}))


function Feed() {
    const classes = useStyles()
    const [posts, setPosts] = useState([])

    const getPosts = useCallback(async () => {
        const feed = await axios.get('/api/home/feed')
        setPosts(feed.data)
    }, [setPosts])

    useEffect(() => {
        getPosts()
    }, [getPosts])

    return (
        <Container maxWidth="lg">
            <Box display="flex">
                <NavBar />
                <div className={classes.root}>
                    {
                        posts.map(post => (
                            <PostCard key={post.id} props={post} />
                        ))
                    }
                </div>
            </Box>
        </Container>

    )
}

export default Feed;