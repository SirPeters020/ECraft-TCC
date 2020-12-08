import moment from 'moment'
import mock from '../utils/mock'

mock.onGet('/api/notifications').reply(200, {
    notifications : [
        {
            id: '909v8svsed7H9dfb',
            title: 'Novo avaliaçãor recebida',
            description: 'você recebeu 1 nova avaliação',
            type: 'review',
            createdAt : moment().subtract(2, 'hours').toDate().getTime()
        },
        {
            id: '123map3e34ekn55',
            title: 'Novo comentario recebida',
            description: 'você recebeu 1 novo comentario',
            type: 'new_comment',
            createdAt : moment().subtract(1, 'day').toDate().getTime()
        },
        {
            id: 'o42355nkol3nm23l',
            title: 'Novo like recebida',
            description: 'você recebeu 1 novo like',
            type: 'like',
            createdAt : moment().subtract(3, 'days').toDate().getTime()
        },
        {
            id: 'l35ubviu23iu5ub23',
            title: 'Novos seguidores',
            description: '2 usuarios começaram a seguir você',
            type: 'connection',
            createdAt : moment().subtract(2, 'hours').toDate().getTime()
        },
    ]
}) 