-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : ven. 02 avr. 2021 à 15:27
-- Version du serveur :  10.4.13-MariaDB
-- Version de PHP : 7.4.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `labo1`
--

-- --------------------------------------------------------

--
-- Structure de la table `fonctions`
--

CREATE TABLE `fonctions` (
  `idfonctions` int(11) NOT NULL,
  `nom_fonction` varchar(45) DEFAULT NULL,
  `niveau_acces` varchar(45) DEFAULT NULL,
  `plages_horaires_idheures` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `fonctions`
--

INSERT INTO `fonctions` (`idfonctions`, `nom_fonction`, `niveau_acces`, `plages_horaires_idheures`) VALUES
(1, 'admin', '1', 1),
(2, 'laborantin', '2', 2);

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

CREATE TABLE `personnel` (
  `idpersonnel` int(11) NOT NULL,
  `nom_personne` varchar(45) DEFAULT NULL,
  `prenom` varchar(45) DEFAULT NULL,
  `fonctions_idfonctions` int(11) NOT NULL,
  `code_rfid` int(5) DEFAULT NULL,
  `num_tel` varchar(10) CHARACTER SET big5 DEFAULT NULL,
  `mail` varchar(45) DEFAULT NULL,
  `passsword` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom_personne`, `prenom`, `fonctions_idfonctions`, `code_rfid`, `num_tel`, `mail`, `passsword`) VALUES
(1, 'lenogue', 'quentin', 1, 6, '0655599955', 'jdzdzdz', 'admin'),
(4, 'tahon', 'sam', 1, 5454, '0502526252', 'samtahon', '1234'),
(6, 'lenogue', 'quentin', 1, 51468418, '0454555', 'fefefefe', 'sasa'),
(7, 'durand', 'korentin', 1, 51468418, '0454555', 'hjdbzfbzj', '1234'),
(8, 'durand', 'gerge', 1, 0, 'efe', 'fe', 'eff'),
(10, 'as', 'sas', 2, 51468418, '0454555', 'sasa', 'dz'),
(16, 'lenogue', 'quentin', 2, 51468418, '0454555', 'fe', 'dz'),
(17, 'lenogue', 'quentin', 2, 51468418, '0454555', 'fe', 'dz');

-- --------------------------------------------------------

--
-- Structure de la table `personnel_produits`
--

CREATE TABLE `personnel_produits` (
  `date_acces` timestamp NULL DEFAULT NULL,
  `personnel_idpersonnel` int(11) NOT NULL,
  `produits_idproduits` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `plages_horaires`
--

CREATE TABLE `plages_horaires` (
  `idheures` int(11) NOT NULL,
  `heures_arrive_max` varchar(45) DEFAULT NULL,
  `heures_depart_max` varchar(45) DEFAULT NULL,
  `full_acces` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `plages_horaires`
--

INSERT INTO `plages_horaires` (`idheures`, `heures_arrive_max`, `heures_depart_max`, `full_acces`) VALUES
(1, '8h30', '17h30', 'non'),
(2, '8h', '18h', 'non');

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

CREATE TABLE `produits` (
  `idproduits` int(11) NOT NULL,
  `nom_produit` varchar(45) DEFAULT NULL,
  `reference` varchar(45) DEFAULT NULL,
  `quantite` float DEFAULT NULL,
  `date_MaJ` timestamp NULL DEFAULT current_timestamp(),
  `numero` int(11) DEFAULT NULL,
  `etagere` varchar(0) DEFAULT NULL,
  `armoire` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `produits`
--

INSERT INTO `produits` (`idproduits`, `nom_produit`, `reference`, `quantite`, `date_MaJ`, `numero`, `etagere`, `armoire`) VALUES
(1, 'dede', 'dede', 1, '2021-04-01 22:00:00', 1, '', 1);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `fonctions`
--
ALTER TABLE `fonctions`
  ADD PRIMARY KEY (`idfonctions`),
  ADD KEY `fk_fonctions_plages_horaires1_idx` (`plages_horaires_idheures`);

--
-- Index pour la table `personnel`
--
ALTER TABLE `personnel`
  ADD PRIMARY KEY (`idpersonnel`),
  ADD KEY `fk_personnel_fonctions_idx` (`fonctions_idfonctions`);

--
-- Index pour la table `personnel_produits`
--
ALTER TABLE `personnel_produits`
  ADD PRIMARY KEY (`personnel_idpersonnel`,`produits_idproduits`),
  ADD KEY `fk_personnel_has_casier_produits1_idx` (`produits_idproduits`);

--
-- Index pour la table `plages_horaires`
--
ALTER TABLE `plages_horaires`
  ADD PRIMARY KEY (`idheures`);

--
-- Index pour la table `produits`
--
ALTER TABLE `produits`
  ADD PRIMARY KEY (`idproduits`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `fonctions`
--
ALTER TABLE `fonctions`
  MODIFY `idfonctions` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `personnel`
--
ALTER TABLE `personnel`
  MODIFY `idpersonnel` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT pour la table `produits`
--
ALTER TABLE `produits`
  MODIFY `idproduits` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `fonctions`
--
ALTER TABLE `fonctions`
  ADD CONSTRAINT `fk_fonctions_plages_horaires1` FOREIGN KEY (`plages_horaires_idheures`) REFERENCES `plages_horaires` (`idheures`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `personnel`
--
ALTER TABLE `personnel`
  ADD CONSTRAINT `fk_personnel_fonctions` FOREIGN KEY (`fonctions_idfonctions`) REFERENCES `fonctions` (`idfonctions`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `personnel_produits`
--
ALTER TABLE `personnel_produits`
  ADD CONSTRAINT `fk_personnel_has_casier_personnel1` FOREIGN KEY (`personnel_idpersonnel`) REFERENCES `personnel` (`idpersonnel`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_personnel_has_casier_produits1` FOREIGN KEY (`produits_idproduits`) REFERENCES `produits` (`idproduits`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
