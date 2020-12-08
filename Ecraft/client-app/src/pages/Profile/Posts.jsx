import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import http from '../../utils/axios';
import PostCard from '../../components/PostCard';

function Posts() {
  const [posts, setPosts] = useState([]);
  const params = useParams();

  useEffect(() => {
    async function fetchPosts() {
      const response = await http.get(`/api/home/posts/user/${params.username}`);
      setPosts(response.data);
    }
    fetchPosts();
  });

  console.log(posts)

  return (
    <>
      {posts.map((post) => (
        <PostCard key={post.id} props={post} />
      ))}
    </>
  );
}

export default Posts;
