import React from "react";
import { Card, ListGroup } from "react-bootstrap";
import { useQuery } from "react-query";
import Categorie from "./Categorie";
const Categories = () => {
  const { data } = useQuery("Categories", () =>
    fetch("https://localhost:7029/api/Categories").then((res) => res.json())
  );
  return (
    <Card style={{ width: "18rem", margin: "2rem",height: "21rem" }}>
      <Card.Header style={{ color: "green" }}>Categorie</Card.Header>
      <ListGroup variant="flush">
        {data ? data.map((e) => <Categorie key={e.id} cat={e} />) : ""}
      </ListGroup>
    </Card>
  );
};

export default Categories;
