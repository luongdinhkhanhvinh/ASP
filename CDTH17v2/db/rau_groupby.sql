SELECT [type],type_name ,count(*) as 'SL'
From post,food_type
where post.type = food_type.type_id
group by [type],type_name