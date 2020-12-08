import moment from 'moment';
import mock from '../utils/mock';

mock.onGet('/api/post/como-bordar-personagens-de-desenhos').reply(200, {
  id: 1,
  title:
    'COMO BORDAR PERSONAGENS DE DESENHOS | Dicas e Truques #02',
  slug: 'como-bordar-personagens-de-desenhos',
  date: moment().subtract(1, 'day').toDate().getTime(),
  author: {
    id: 1,
    name: 'Pedro Augusto',
    avatar: '/images/avatar/maxresdefault.jpg',
  }, 
  markdownText: `
  _Compact style:_
  
  Term 1
    ~ Definition 1
  
  Term 2
    ~ Definition 2a
    ~ Definition 2b`,
  tags: ['croche', 'croche-tunisiano', 'croche-avançado'],
  image: '/images/posts/1574678762256.png',
  likes: 10,
  comments: 30,
});

mock.onGet('/api/feed').reply(200, {
  posts: [
    {
      id: 1,
      title:
        'COMO BORDAR PERSONAGENS DE DESENHOS | Dicas e Truques #02',
      slug: 'como-bordar-personagens-de-desenhos',
      date: moment().subtract(1, 'day').toDate().getTime(),
      author: {
        id: 1,
        name: 'Pedro Augusto',
        avatar: '/images/avatar/maxresdefault.jpg',
      },
      tags: ['croche', 'croche-tunisiano', 'croche-avançado'],
      image: '/images/posts/plantinha.jpeg',
      likes: 10,
      comments: 30,
    },
    {
      id: 2,
      title: 'COMO FAZER CROCHE TUNISIANO | Tips & Tricks - croche-tunisiano #01',
      slug: 'como-fazer-croche-tunisiano',
      date: moment().subtract(1, 'day').toDate().getTime(),
      author: {
        id: 1,
        name: 'Pedro Augusto',
        avatar: '/images/avatar/maxresdefault.jpg',
      },
      tags: ['reactjs', 'javascript'],
      image: '/images/posts/cachecol.jpeg',
      likes: 5,
      comments: 1,
    },
  ],
});

mock.onGet('/api/posts/user/pedroaugusto').reply(200, {
  posts: [
    {
      id: 1,
      title:
        'COMO BORDAR PERSONAGENS DE DESENHOS | Dicas e Truques #02',
      slug: 'como-bordar-personagens-de-desenhos',
      date: moment().subtract(1, 'day').toDate().getTime(),
      author: {
        id: 1,
        name: 'Pedro Augusto',
        avatar: '/images/avatar/maxresdefault.jpg',
      },
      tags: ['bordado', 'desenho', 'bordado-avançado'],
      image: '/images/posts/plantinha.jpeg',
      likes: 10,
      comments: 30,
    },
    {
      id: 2,
      title: 'COMO FAZER CROCHE TUNISIANO | Tips & Tricks - croche-tunisiano #01',
      slug: 'como-fazer-croche-tunisiano',
      date: moment().subtract(1, 'day').toDate().getTime(),
      author: {
        id: 1,
        name: 'Pedro Augusto',
        avatar: '../../../',
      },
      tags: ['croche', 'croche-tunisiano', 'croche-avançado'],
      image: '/images/posts/cachecol.jpeg',
      likes: 5,
      comments: 1,
    },
  ],
});