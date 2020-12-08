import mock from '../utils/mock'

mock.onPost('/api/home/me').reply(200, {
    user: {
        id: 1,
        nome: 'Pedro Augusto',
        username: 'pedroaugusto',
        email: 'pedroaugusto@gmail.com',
        avatar: '/images/avatar/maxresdefault.jpg'
    }
})
mock.onPost('/api/home/login').reply((config) => {
    const { email, password } = JSON.parse(config.data)
    if (email !== 'pedro@pedro.com' || password !== 'admin') {
        return [400, { message: 'Email ou senha invalido' }]
    }

    const user = {
        id: 1,
        nome: 'Pedro Augusto',
        username: 'pedroaugusto',
        avatar: '/images/avatar/maxresdefault.jpg'
    }

    return [200, { user }]
})
mock.onGet('/api/home/user/pedroaugusto').reply(200, {
    id: 1,
    name: 'Pedro Augusto',
    username: 'pedroaugusto',
    email: 'pedro@pedro.com',
    accessToken: 'dadadadadadadad',
    avatar: '/images/avatar/maxresdefault.jpg',
    joinedIn: '06 de janeiro, 2020',
    work: 'Developer',
    totalPost: '388',
  });
  