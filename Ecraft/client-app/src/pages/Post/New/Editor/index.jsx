import React, { useCallback } from 'react'

import Autocomplete from '@material-ui/lab/Autocomplete';
import TextField from '@material-ui/core/TextField'
import Box from '@material-ui/core/Box'
import { makeStyles, withStyles  } from '@material-ui/core/styles'
import Button from '@material-ui/core/Button'
import { useDropzone } from 'react-dropzone'

import FormControl from '@material-ui/core/FormControl';
import InputLabel from '@material-ui/core/InputLabel';
import NativeSelect from '@material-ui/core/NativeSelect';
import InputBase from '@material-ui/core/InputBase';


import { usePost } from '../../../../context/PostContext'
import Title from './Title'

const useStyles = makeStyles((theme) => ({
    image: {
        height: 100
    },
    textArea: {
        width: '100%',
        height: '100%',
        resize: 'none',
        border: 'none',
        outline: 'none',
        fontSize: 15,
    },
    button: {
        marginRight: theme.spacing(2)
    },
    margin: {
        margin: theme.spacing(1),
    },
}))


const BootstrapInput = withStyles((theme) => ({
    root: {
        'label + &': {
            marginTop: theme.spacing(3),
        },
    },
    input: {
        borderRadius: 4,
        position: 'relative',
        backgroundColor: theme.palette.background.paper,
        border: '1px solid #ced4da',
        fontSize: 16,
        padding: '10px 26px 10px 12px',
        transition: theme.transitions.create(['border-color', 'box-shadow']),
        // Use the system font instead of the default Roboto font.
        fontFamily: [
            '-apple-system',
            'BlinkMacSystemFont',
            '"Segoe UI"',
            'Roboto',
            '"Helvetica Neue"',
            'Arial',
            'sans-serif',
            '"Apple Color Emoji"',
            '"Segoe UI Emoji"',
            '"Segoe UI Symbol"',
        ].join(','),
        '&:focus': {
            borderRadius: 4,
            borderColor: '#80bdff',
            boxShadow: '0 0 0 0.2rem rgba(0,123,255,.25)',
        },
    },
}))(InputBase);


const arrayTags = [
    { title: 'Croche' },
    { title: 'Bordado' },
    { title: 'Croche-Tunisiano' },
    { title: 'SkatchBook' },
    { title: 'Trico' },
    { title: 'Origami' },
    { title: 'Pintura Com Agulha' },
]

function PostEditor() {
    const classes = useStyles()
    const ctx = usePost()

    const { image, setImage, tags, setTags, type, setType, markdownText, setMarkdownText } = ctx

    const onDrop = useCallback(acceptedFile => {
        const file = acceptedFile[0]
        const reader = new FileReader()
        reader.readAsDataURL(file)
        reader.onloadend = () => {
            const base64data = reader.result
            setImage(base64data)
        }
    }, [setImage])

    const { getRootProps, getInputProps } = useDropzone({
        onDrop,
        multiple: false,
        accept: 'image/*'
    })

    

    return (
        <>
            <Box {...getRootProps()} mb={2} >
                <input {...getInputProps()} />
                <Button>Carregar Imagem</Button>
            </Box>
            {image && (
                <Box mb={2} >
                    <img className={classes.image} src={image} alt="background" />
                </Box>
            )}
            <Box mb={1} >
                <Title />
            </Box>
            <Box mb={2} >
                <Autocomplete
                    multiple
                    id="tags-standard"
                    options={arrayTags}
                    getOptionLabel={(option) => option.title}
                    value={tags}
                    onChange={setTags}
                    renderInput={(params) => (
                        <TextField
                            {...params}
                            variant="standard"
                            placeholder="Tags"
                        />
                    )}
                />
            </Box>

            <FormControl className={classes.margin}>
                <InputLabel htmlFor="demo-customized-select-native">Categoria</InputLabel>
                <NativeSelect
                    id="demo-customized-select-native"
                    value={type}
                    onChange={setType}
                    input={<BootstrapInput />}
                >
                    <option aria-label="None" value="" />
                    <option value={'projetos'}>Projeto</option>
                    <option value={'receitas'}>Receita</option>
                    <option value={'perguntas'}>Pergunta</option>
                </NativeSelect>
            </FormControl>

            <textArea className={classes.textArea} onChange={setMarkdownText} value={markdownText} ></textArea>
        </>
    )
}

export default PostEditor