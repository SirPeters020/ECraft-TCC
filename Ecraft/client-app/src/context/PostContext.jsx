import React, { createContext, useState, useContext } from 'react'

export const PostContext = createContext()

export function PostProvider({ children }) {
    const [image, setImage] = useState(null)
    const [title, setTitle] = useState('')
    const [tags, setTags] = useState([])
    const [type, setType] = useState('')
    const [markdownText, setMarkdownText] = useState('')

    const handleChangeTitle = (event) => {
        setTitle(event.currentTarget.value)
    }

    const handleTagsChange = (event, values) => {
        setTags(values)
    }

    const handleChangeMarkdown = (event) => {
        setMarkdownText(event.currentTarget.value)
    }

    const handleChangeType = (event) => {
        setType(event.target.value);
    };

    return (
        <PostContext.Provider value={{
            image, setImage,
            title, setTitle: handleChangeTitle,
            tags, setTags: handleTagsChange,
            type, setType : handleChangeType,
            markdownText, setMarkdownText: handleChangeMarkdown
        }}>
            {children}
        </PostContext.Provider>
    )
}

export function usePost() {
    const ctx = useContext(PostContext)
    const { title, setTitle, image, setImage, tags, setTags, type, setType, markdownText, setMarkdownText } = ctx

    return {
        title, setTitle, image, setImage, tags, setTags, type, setType, markdownText, setMarkdownText
    }
}