import React, { useState } from 'react'
import Box from '@material-ui/core/Box'
import Divider from '@material-ui/core/Divider'
import Markdown from 'react-markdown'

import PostEditor from './Editor'
import PostPreview from './Preview'
import BottomBar from './BottomBar'
import { PostProvider }  from '../../../context/PostContext'


function NewPost() {
    
    return (
        <PostProvider>
            <Box display="flex" height="calc(100% - 70px)" overflow="scroll">
                <Box width="50%" height="100%" padding={2} borderRight="1px solid #ddd">
                    <PostEditor />
                </Box>
                <Box width="50%" height="100%" padding={2}>
                    <PostPreview />
                </Box>
                {/* <Divider />
                <Markdown/> */}
                <BottomBar />
            </Box>
            
        </PostProvider>
    )
}

export default NewPost