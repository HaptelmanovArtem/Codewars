-- https://leetcode.com/problems/combine-two-tables/

select i.firstName, i.lastName, j.city, j.state from Persons as i
left join Address as j on i.personId = j.personId