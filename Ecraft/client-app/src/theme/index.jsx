import { createMuiTheme } from '@material-ui/core/styles'
import { colors } from '@material-ui/core'
import typography from './typography'

const theme = createMuiTheme({
    palette: {
        primary: {
          main: colors.red[500],
          dark: colors.red[900],
          light: colors.red[300]
        },
        secondary: {
          main: colors.deepPurple[500]
        },
      },
      typography
})

export default theme