PGDMP                         x            ServiceConsulting    12.2    12.2 	               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            	           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            
           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    17156    ServiceConsulting    DATABASE     �   CREATE DATABASE "ServiceConsulting" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';
 #   DROP DATABASE "ServiceConsulting";
                postgres    false            �            1259    17165    Consultation    TABLE     �   CREATE TABLE public."Consultation" (
    id numeric NOT NULL,
    "RecState" integer NOT NULL,
    "CreationDateTime" date NOT NULL,
    "PatientSymptoms" text,
    "User" numeric NOT NULL
);
 "   DROP TABLE public."Consultation";
       public         heap    postgres    false            �            1259    17157    User    TABLE     '  CREATE TABLE public."User" (
    id numeric NOT NULL,
    "RecState" integer NOT NULL,
    "CreationDateTime" date NOT NULL,
    "FirstName" text NOT NULL,
    "SecondName" text NOT NULL,
    "MiddleName" text,
    "BirthDay" date NOT NULL,
    "Sex" text NOT NULL,
    "Snils" text NOT NULL
);
    DROP TABLE public."User";
       public         heap    postgres    false            �
           2606    17172    Consultation Consultation_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."Consultation"
    ADD CONSTRAINT "Consultation_pkey" PRIMARY KEY (id);
 L   ALTER TABLE ONLY public."Consultation" DROP CONSTRAINT "Consultation_pkey";
       public            postgres    false    203            �
           2606    17164    User User_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY (id);
 <   ALTER TABLE ONLY public."User" DROP CONSTRAINT "User_pkey";
       public            postgres    false    202            �
           2606    17173    Consultation User    FK CONSTRAINT     ~   ALTER TABLE ONLY public."Consultation"
    ADD CONSTRAINT "User" FOREIGN KEY ("User") REFERENCES public."User"(id) NOT VALID;
 ?   ALTER TABLE ONLY public."Consultation" DROP CONSTRAINT "User";
       public          postgres    false    202    203    2692           