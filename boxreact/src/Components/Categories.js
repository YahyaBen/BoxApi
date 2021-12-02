import React, { useEffect, useState } from "react";
import { Card, ListGroup } from "react-bootstrap";
import { useQuery } from "react-query";
import Categorie from "./Categorie";
import OStock from "./OStock";
const Categories = () => {
  const [Stock, setStock] = useState([]);
  const [Somme, setSomme] = useState(0);
  const [Boxes, SetBoxes] = useState([]);

  const SetSomme = (A) => {
    setSomme(Somme + A);
  };

  const getStock = (id) => {
    fetch("https://localhost:7029/api/Stock_Categories")
      .then((res) => res.json())
      .then((e) => setStock(e.filter((e) => e.CategoryId === id)));
  };

  useEffect(() => {
    const getAllStock = () => {
      fetch("https://localhost:7029/api/Stock_Categories")
        .then((res) => res.json())
        .then((e) => setStock(e));
    };

    const getAllBox = () => {
      fetch("https://localhost:7029/api/boxes")
        .then((res) => res.json())
        .then((e) => SetBoxes(e));
    };
    getAllBox();
    getAllStock();
  }, []);
  const { data, isLoading } = useQuery("Categories", () =>
    fetch("https://localhost:7029/api/Categories").then((res) => res.json())
  );

  const Box = useQuery("boxes", () =>
    fetch("https://localhost:7029/api/boxes").then((res) => res.json())
  );

  return (
    <>
      {isLoading === false ? (
        <>
          <Card style={{ width: "18rem", margin: "2rem", height: "21rem" }}>
            <Card.Header style={{ color: "green" }}>Categorie</Card.Header>
            <ListGroup variant="flush">
              {data
                ? data.map((e) => (
                    <Categorie key={e.id} cat={e} getStk={getStock} />
                  ))
                : ""}
            </ListGroup>
          </Card>
          <Card style={{ width: "18rem", margin: "2rem", height: "40rem" }}>
            <Card.Header style={{ color: "green" }}>Object Stock</Card.Header>
            <ListGroup variant="flush">
              {Stock
                ? Stock.map((e) => (
                    <OStock key={e.id} Stk={e} somme={SetSomme} />
                  ))
                : ""}
            </ListGroup>
          </Card>
          <Card style={{ width: "18rem", margin: "2rem", height: "21rem" }}>
            <Card.Header style={{ color: "green", fontSize: "36px" }}>
              Volume Calculer m³
            </Card.Header>
            <ListGroup
              variant="flush"
              style={{ fontSize: "24px", paddingTop: "2rem" }}
            >
              {Somme} m³ <br></br>
              <strong>Le Box ideal est </strong>{" "}
              {Boxes.find((element) => element.volume > Somme)!== undefined ? Boxes.find((element) => element.volume > Somme).nom : "Contacter nous"}
            </ListGroup>
          </Card>
        </>
      ) : (
        ""
      )}
    </>
  );
};

export default Categories;
